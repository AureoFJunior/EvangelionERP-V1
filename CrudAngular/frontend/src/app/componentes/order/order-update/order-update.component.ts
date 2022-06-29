import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderProduct } from '../../product/orderProduct.model';
import { Product } from '../../product/product.model';
import { ProductService } from '../../product/product.service';
import { Order } from '../order.model';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-order-update',
  templateUrl: './order-update.component.html',
  styleUrls: ['./order-update.component.css']
})
export class OrderUpdateComponent implements OnInit {

  form!: FormGroup;
  productsArray: Product[] = [];
  displayedColumns: String[] = ['id', 'name', 'quantity', 'price']
  data: number = 0;
  createBtnVisible: boolean = true;
  orderStatus: string = "";
  orderCod: string | null | undefined
  order: Order = {
    cod: undefined,
    creationDate: new Date(),
    status: 0,
    productsQuantity: 0,
    totalValue: 0,
    flOutput: false
  }

  constructor(private orderService: OrderService, private productService: ProductService,
    private router: Router, private route: ActivatedRoute, private formBuilder: FormBuilder) { }


  ngOnInit(): void {
    this.orderCod = this.route.snapshot.paramMap.get('id')
    this.orderStatus = this.route.snapshot.paramMap.get('status')!
    let number: number = Number(this.orderCod)

    this.form = this.formBuilder.group({
      products: this.formBuilder.array([])
    });

    this.productService.getAllAsFormArrayUpdate(number).subscribe(products => {
      this.form.setControl('products', products);
      this.att()
    });

    this.productService.read().subscribe(products => {
      this.productsArray = products.productsDetails
    })
    
  }

  get products(): FormArray {
    return this.form.get('products') as FormArray;
  }

  create(): void {
    
    let number: number = Number(this.orderCod)
    this.orderService.create(this.order).subscribe(() => {
    })

    var products: OrderProduct[] = this.form.get('products')?.value

    //Validações do pedido
    for (let i = 0; i < products.length; i++) 
    {
      //Preenche os dados do pedido
      this.order.creationDate = new Date();
      this.order.productsQuantity += products[i].quantity;
      this.order.status = 1;

      //Vincula os produtos com o pedido
      products[i].orderCod = number;
      products[i].productCod = products[i].cod
      products[i].cod = 0 

      if (products[i].quantity === null) {
        products[i].quantity = 0
      }

    }
    this.updateItens(products[0].orderCod, products)
  }

  updateItens(orderCod: number, products: OrderProduct[]): void {
    //Exclui os itens existentes e insere novamente.
    this.orderService.deleteItens(orderCod).subscribe(() => {
      this.addItens(products)
    })
  }

  addItens(products: OrderProduct[]): void {
    //Manda os itens já vinculados com o pedido e com os dados preenchidos.
    this.orderService.addItem(products).subscribe(() => {
      this.order.totalValue = this.data
      this.updateOrder(this.order)
    })
  }

  updateOrder(order: Order): void {
    this.order.cod = Number(this.orderCod)

    this.orderService.update(order).subscribe(() => {
      this.orderService.showMessage('Pedido gravado com sucesso!', 'sucesso')
      this.router.navigate(['/orders'])
    })
  }

  clean(): void {
    this.router.navigate(['/orders/create'])
  }

  cancel(): void {
    this.router.navigate(['/orders'])
  }

  att(): void {
    var products: OrderProduct[] = this.form.get('products')?.value
    this.data = 0
    for (let i = 0; i < products.length; i++) {
      //Preenche os dados do pedido
      this.data += (products[i].price * products[i].quantity)
    }
  }

  finish(): void {
    this.orderService.readById(this.orderCod!).subscribe((orderResult) => {
      this.order = orderResult
      this.order.status = 2
      this.updateOrder(this.order)
    })
  }

}

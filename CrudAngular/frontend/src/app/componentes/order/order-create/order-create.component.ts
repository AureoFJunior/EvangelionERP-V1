import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../../product/product.model';
import { ProductService } from '../../product/product.service';
import { OrderService } from '../order.service';
import { FormArray, FormGroup, FormBuilder } from '@angular/forms';
import { OrderProduct } from '../../product/orderProduct.model';
import { isNull } from '@angular/compiler/src/output/output_ast';
import { Order } from '../order.model';

@Component({
  selector: 'app-order-create',
  templateUrl: './order-create.component.html',
  styleUrls: ['./order-create.component.css']
})
export class OrderCreateComponent implements OnInit {

  form!: FormGroup;
  productsArray: Product[] = [];
  displayedColumns: String[] = ['id', 'name', 'quantity', 'price']
  data: number = 0
  output: boolean = true
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

    this.form = this.formBuilder.group({
      products: this.formBuilder.array([])
    });

    this.productService.getAllAsFormArray().subscribe(products => {
      this.form.setControl('products', products);
    });

    this.productService.read().subscribe(products => {
      this.productsArray = products.productsDetails
    })

  }

  get products(): FormArray {
    return this.form.get('products') as FormArray;
  }

  create(): void {
    
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
      products[i].orderCod = 0;
      products[i].productCod = products[i].cod;
      products[i].cod = 0;
      products[i].flOutput = this.output;

      if (products[i].quantity === null) {
        products[i].quantity = 0;
      }

    }
    this.addItens(products)
  }

  addItens(products: OrderProduct[]): void {
    //Manda os itens já vinculados com o pedido e com os dados preenchidos.
    this.orderService.addItem(products).subscribe(() => {
      this.order.totalValue = this.data;
      this.updateOrder();
    })
  }

  updateOrder(): void {
    this.order.cod = 0
    this.order.flOutput = this.output

    this.orderService.update(this.order).subscribe(() => {
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
      this.data += Math.round((products[i].price * products[i].quantity) * 100)  / 100
    }
  }
}

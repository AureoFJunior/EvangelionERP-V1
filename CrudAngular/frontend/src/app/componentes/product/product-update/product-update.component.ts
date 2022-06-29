import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../product.model';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-update',
  templateUrl: './product-update.component.html',
  styleUrls: ['./product-update.component.css']
})
export class ProductUpdateComponent implements OnInit {

  constructor(private productService: ProductService, private router: Router, private route: ActivatedRoute) { }

  product: Product = {
    name: '',
    price: 0,
    quantity: 0
  }
  
  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id')

    this.productService.readById(id!).subscribe(product => {
      this.product = product
    });
  }

  navigate(): void {
    this.router.navigate(['/products']);
  }

  updateProduct(): void {
    this.productService.update(this.product).subscribe(() => {
      this.productService.showMessage(`Produto [${this.product.name}] atualizado com sucesso! :)`, 'sucesso');
      this.navigate();
    });
  }

  cancel(): void {
    this.navigate();
    this.productService.showMessage('Operação de edição cancelada :( ', 'erro');
  }

}

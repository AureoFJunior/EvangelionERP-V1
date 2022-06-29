import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Product } from '../product.model';
import { ProductService } from './../product.service';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {

  //Inicializar o produto para ser utilizado posteriormente. 
  product: Product = {
    name: '',
    price: 0,
    quantity: 0
  }

  constructor(private productService: ProductService, private router: Router) { }

  ngOnInit(): void {
  }

  //Função que verifica a criação do produto e então chama a função do Service para realmente criar o produto no banco de dados.
  createProduct(): void {
    if (this.product.name !== "") {
      this.productService.create(this.product).subscribe(() => {
        this.productService.showMessage('Operação concluída com sucesso!', 'sucesso')
        
        this.router.navigate(['/products'])
      })
  }
  //Não deixa cadastrar se estiver vazio o nome do produto.
  else 
  {
    this.productService.showMessage('O nome do produto precisa ser preenchido. Verifique', 'erro')
    this.router.navigate(['/products/create'])
  }
}

  //Aqui é só pra voltar pra tela de produtos mesmo.
  cancel(): void {
    this.router.navigate(['/products'])
    this.productService.showMessage('Cadastro de produto cancelado', 'atencao')
  }

}

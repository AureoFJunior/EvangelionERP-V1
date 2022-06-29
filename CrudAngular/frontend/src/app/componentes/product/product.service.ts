import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EMPTY, Observable, ObservedValueOf } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { FormArray } from '@angular/forms';
import { Product } from './product.model';
import { OrderProduct } from './orderProduct.model';
import { StorageService } from 'src/app/services/storage.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  //URL base da aplicação
  baseUrl: string = 'https://localhost:44396/api/Product'

  constructor(private snackBar: MatSnackBar, private httpClient: HttpClient, private storageService: StorageService) { }

  //Quando inserir o produto, mostra a mensagem de sucesso.
  showMessage(msg: string, action: string): void {
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top",
      panelClass: action
    })
  }

  //Cadastra o produto
  create(product: Product): Observable<Product> {
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers = headers.append('Content-Type', 'application/json')
    headers = headers.append('Access-Control-Allow-Origin', '*')
    headers = headers.append('Authorization', 'Bearer ' + token)

    return this.httpClient.post<Product>(`${this.baseUrl}/add_product`, product, { headers: headers }).pipe(
      map((obj) => obj),
      catchError((e) => this.errorhandler(e))
    );
  }

  //Pega o erro para mostrar na Snack Bar
  errorhandler(e: any): Observable<any> {
    this.showMessage('Ocorreu um erro inesperado.', 'erro')
    return EMPTY;
  }

  //Lê os produtos
  read() {
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers = headers.append('Content-Type', 'application/json')
    headers = headers.append('Access-Control-Allow-Origin', '*')
    headers = headers.append('Authorization', 'Bearer ' + token)

    return this.httpClient.get<any>(`${this.baseUrl}/get_products`, {headers: headers}).pipe(map((res: any) => {
      return res;
    }))
  }

  //Procura um produto com base em um Cod
  readById(cod: string): Observable<Product> {
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers = headers.append('Content-Type', 'application/json')
    headers = headers.append('Access-Control-Allow-Origin', '*')
    headers = headers.append('Authorization', 'Bearer ' + token)

    const url = `${this.baseUrl}/get_product/${cod}`
    return this.httpClient.get<Product>(url, {headers: headers})
  }

  //Atualiza o produto
  update(product: Product): Observable<Product> {
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers = headers.append('Content-Type', 'application/json')
    headers = headers.append('Access-Control-Allow-Origin', '*')
    headers = headers.append('Authorization', 'Bearer ' + token)

    const url = `${this.baseUrl}/update_product`
    return this.httpClient.put<Product>(url, product, {headers: headers})
  }

  //Deleta o produto
  delete(cod: string): Observable<Product> {
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers = headers.append('Content-Type', 'application/json')
    headers = headers.append('Access-Control-Allow-Origin', '*')
    headers = headers.append('Authorization', 'Bearer ' + token)

    const url = `${this.baseUrl}/delete_product/${cod}`
    return this.httpClient.delete<Product>(url, {headers: headers})
  }

  getAll(): Observable<OrderProduct[]> {
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers = headers.append('Content-Type', 'application/json')
    headers = headers.append('Access-Control-Allow-Origin', '*')
    headers = headers.append('Authorization', 'Bearer ' + token)

    return this.httpClient.get<OrderProduct[]>(`${this.baseUrl}/get_products_only`, {headers: headers})
    .pipe(map((prod: OrderProduct[]) => {
      return prod;
    }));
  }

  //Pega todos os produtos para jogar no Form e então ser utilizado na tabela dos pedidos.
  getAllAsFormArray(): Observable<FormArray> {
    return this.getAll().pipe(map((products: OrderProduct[]) => {
      const fgs = products.map(OrderProduct.asFormGroup);
      return new FormArray(fgs);
    }));
  }

  getAllUpdate(orderCod: number): Observable<OrderProduct[]> {
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers = headers.append('Content-Type', 'application/json')
    headers = headers.append('Access-Control-Allow-Origin', '*')
    headers = headers.append('Authorization', 'Bearer ' + token)

    return this.httpClient.get<OrderProduct[]>(`https://localhost:44396/api/Order/get_order_products/${orderCod}`, {headers: headers})
    .pipe(map((prod: OrderProduct[]) => {
      return prod;
    }));
  }

  //Pega todos os produtos para jogar no Form e então ser utilizado na tabela dos pedidos.
  getAllAsFormArrayUpdate(orderCod: number): Observable<FormArray> {
    return this.getAllUpdate(orderCod).pipe(map((products: OrderProduct[]) => {
      const fgs = products.map(OrderProduct.asFormGroup);
      return new FormArray(fgs);
    }));
  }

}

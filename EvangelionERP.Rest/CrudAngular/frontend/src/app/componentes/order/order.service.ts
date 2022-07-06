import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EMPTY, Observable, ObservedValueOf } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { StorageService } from 'src/app/services/storage.service';
import { OrderProduct } from '../product/orderProduct.model';
import { Order } from './order.model';


@Injectable({
  providedIn: 'root'
})
export class OrderService {

  //URL base da aplicação
  baseUrl: string = 'https://localhost:44396/api/Order'

  constructor(private snackBar: MatSnackBar, private httpClient: HttpClient, private storageService: StorageService) { }

  //Quando inserir o pedido, mostra a mensagem de sucesso.
  showMessage(msg: string, action: string): void {
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top",
      panelClass: action
    })
  }

  //Cadastra os produtos do pedido
  addItem(product: OrderProduct[]): Observable<OrderProduct[]> {
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers = headers.append('Content-Type', 'application/json')
    headers = headers.append('Access-Control-Allow-Origin', '*')
    headers = headers.append('Authorization', 'Bearer ' + token)
    
    return this.httpClient.post<OrderProduct[]>(`${this.baseUrl}/add_order_products`, product, { headers: headers }).pipe(
      map((obj) => obj),
      catchError((e) => this.errorhandler(e))
    );
  }

  //Cadastra o pedido
  create(order: Order): Observable<Order> {
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers = headers.append('Content-Type', 'application/json')
    headers = headers.append('Access-Control-Allow-Origin', '*')
    headers = headers.append('Authorization', 'Bearer ' + token)

    return this.httpClient.post<Order>(`${this.baseUrl}/add_order`, order, { headers: headers }).pipe(
      map((obj) => obj),
      catchError((e) => this.errorhandler(e))
    );
  }

  //Pega o erro para mostrar na Snack Bar
  errorhandler(e: any): Observable<any> {
    this.showMessage('Ocorreu um erro inesperado.', 'erro')
    return EMPTY;
  }

  //Lê os pedidos
  read() {
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers = headers.append('Content-Type', 'application/json')
    headers = headers.append('Access-Control-Allow-Origin', '*')
    headers = headers.append('Authorization', 'Bearer ' + token)
    
    return this.httpClient.get<any>(`${this.baseUrl}/get_orders`, { headers: headers}).pipe(map((res: any) => {
      return res;
    }))
  }

  readProducts(cod: string) {
    return this.httpClient.get<any>(`${this.baseUrl}/get_orders_products/${cod}`).pipe(map((res: any) => {
      return res;
    }))
  }

  //Procura um pedido com base em um Cod
  readById(cod: string): Observable<Order> {
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers = headers.append('Content-Type', 'application/json')
    headers = headers.append('Access-Control-Allow-Origin', '*')
    headers = headers.append('Authorization', 'Bearer ' + token)

    const url = `${this.baseUrl}/get_order/${cod}`
    return this.httpClient.get<Order>(url, {headers: headers})
  }

  //Atualiza o pedido
  update(order: Order): Observable<Order> {
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers = headers.append('Content-Type', 'application/json')
    headers = headers.append('Access-Control-Allow-Origin', '*')
    headers = headers.append('Authorization', 'Bearer ' + token)

    const url = `${this.baseUrl}/update_order`
    return this.httpClient.put<Order>(url, order, { headers: headers})
  }

  deleteItens(orderCod: number): Observable<Order> {
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers = headers.append('Content-Type', 'application/json')
    headers = headers.append('Access-Control-Allow-Origin', '*')
    headers = headers.append('Authorization', 'Bearer ' + token)

    const url = `${this.baseUrl}/delete_order_product/${orderCod}`
    return this.httpClient.delete<Order>(url, {headers: headers})
  }

  //Deleta o pedido
  delete(cod: string): Observable<Order> {
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers = headers.append('Content-Type', 'application/json')
    headers = headers.append('Access-Control-Allow-Origin', '*')
    headers = headers.append('Authorization', 'Bearer ' + token)

    const url = `${this.baseUrl}/delete_order/${cod}`
    return this.httpClient.delete<Order>(url, {headers: headers})
  }

}

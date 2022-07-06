import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { User } from './user.model';
import { EMPTY, Observable } from 'rxjs';
import { catchError, defaultIfEmpty, filter, first, isEmpty, map } from 'rxjs/operators';
import { StorageService } from 'src/app/services/storage.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  //URL base da aplicação
  baseUrl: string = 'https://localhost:44396/api/Login';
  authUser: boolean = false;
  fodase: Observable<User> = new Observable<User>()

  constructor(private snackBar: MatSnackBar, private httpClient: HttpClient, private storageService: StorageService) { }

  //Quando inserir o usuário, mostra a mensagem de sucesso.
  showMessage(msg: string, action: string): void {
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top",
      panelClass: action
    })
  }

  //Cadastra o usuário
  create(user: User): Observable<User> {
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers = headers.append('Content-Type', 'application/json')
    headers = headers.append('Access-Control-Allow-Origin', '*')
    headers = headers.append('Authorization', 'Bearer ' + token)

    return this.httpClient.post<User>(`${this.baseUrl}/signup`, user, { headers: headers }).pipe(
      map((obj) => obj),
      catchError((e) => this.errorhandler(e))
          );
  }

  //Pega o erro para mostrar na Snack Bar
  errorhandler(e: any): Observable<any> {
    this.showMessage('Ocorreu um erro inesperado.', 'erro')
    return EMPTY;
  }

  //Lê os usuários
  read() {
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers = headers.append('Content-Type', 'application/json')
    headers = headers.append('Access-Control-Allow-Origin', '*')
    headers = headers.append('Authorization', 'Bearer ' + token)

    return this.httpClient.get<any>(`${this.baseUrl}/users`, {headers: headers}).pipe(map((res: any) => {
      return res;
    }))
  }

  changeStatus(user: User) {
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers = headers.append('Content-Type', 'application/json')
    headers = headers.append('Access-Control-Allow-Origin', '*')
    headers = headers.append('Authorization', 'Bearer ' + token)

    this.httpClient.post<User>(`${this.baseUrl}/changeStatus`, user, { headers: headers }).pipe(
      map((obj) => obj),
      catchError((e) => this.errorhandler(e))
    );
  }

  hasValue(value: any) {
    return value !== null && value !== undefined;
  }

  login(user: User): Observable<any> {
    const headers = new HttpHeaders()
    headers.set('Content-Type', 'application/json')
    headers.set('Access-Control-Allow-Origin', '*')

    let login = this.httpClient.post<User>(`${this.baseUrl}/login`, user, { headers: headers }).pipe(
      map((obj) => obj),
      catchError((e) => this.errorhandler(e))
    );
    
    if (login === this.fodase) {
      this.authUser = false
    }
    else {
      this.authUser = true
    }
    return login
  }

  isLogged(): Observable<User> {
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers = headers.append('Content-Type', 'application/json')
    headers = headers.append('Access-Control-Allow-Origin', '*')
    headers = headers.append('Authorization', 'Bearer ' + token)

    return this.httpClient.get<any>(`${this.baseUrl}/isLogged`, {headers: headers}).pipe(map((res: any) => {
      return res;
    }))
  }

  userAuthenticator() {
    return this.authUser
  }

}

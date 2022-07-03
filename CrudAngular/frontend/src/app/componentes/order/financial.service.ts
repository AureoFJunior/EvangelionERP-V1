import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EMPTY, Observable, ObservedValueOf } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { StorageService } from 'src/app/services/storage.service';
import { Financial } from '../order/financial.model';

@Injectable({
    providedIn: 'root'
})
export class FinancialService {

    //URL base da aplicação
    baseUrl: string = 'https://localhost:44396/api/Financial'

    constructor(private snackBar: MatSnackBar, private httpClient: HttpClient, private storageService: StorageService) { }

    //Quando inserir o financeiro, mostra a mensagem de sucesso.
    showMessage(msg: string, action: string): void {
        this.snackBar.open(msg, 'X', {
            duration: 3000,
            horizontalPosition: "right",
            verticalPosition: "top",
            panelClass: action
        })
    }

    //Cadastra o financeiro
    create(financial: Financial): Observable<Financial> {
        let headers = new HttpHeaders()
        const token = this.storageService.getData('token')

        headers = headers.append('Content-Type', 'application/json')
        headers = headers.append('Access-Control-Allow-Origin', '*')
        headers = headers.append('Authorization', 'Bearer ' + token)

        return this.httpClient.post<Financial>(`${this.baseUrl}/add_financial`, financial, { headers: headers }).pipe(
            map((obj) => obj),
            catchError((e) => this.errorhandler(e))
        );
    }

    //Pega o erro para mostrar na Snack Bar
    errorhandler(e: any): Observable<any> {
        this.showMessage('Ocorreu um erro inesperado.', 'erro')
        return EMPTY;
    }

    //Lê o financeiro
    read() {
        let headers = new HttpHeaders()
        const token = this.storageService.getData('token')

        headers = headers.append('Content-Type', 'application/json')
        headers = headers.append('Access-Control-Allow-Origin', '*')
        headers = headers.append('Authorization', 'Bearer ' + token)

        return this.httpClient.get<any>(`${this.baseUrl}/get_financials/${Date.now}`, { headers: headers }).pipe(map((res: any) => {
            return res;
        }))
    }

    readById() {
        let headers = new HttpHeaders()
        const token = this.storageService.getData('token')

        headers = headers.append('Content-Type', 'application/json')
        headers = headers.append('Access-Control-Allow-Origin', '*')
        headers = headers.append('Authorization', 'Bearer ' + token)

        return this.httpClient.get<any>(`${this.baseUrl}/get_financial/${Date.now}`, { headers: headers }).pipe(map((res: any) => {
            return res;
        }))
    }

    //Atualiza o financeiro
    update(financial: Financial): Observable<Financial> {
        let headers = new HttpHeaders()
        const token = this.storageService.getData('token')

        headers = headers.append('Content-Type', 'application/json')
        headers = headers.append('Access-Control-Allow-Origin', '*')
        headers = headers.append('Authorization', 'Bearer ' + token)

        const url = `${this.baseUrl}/update_financial`
        return this.httpClient.put<Financial>(url, financial, { headers: headers })
    }

    //Deleta o financeiro
    delete(cod: string): Observable<Financial> {
        let headers = new HttpHeaders()
        const token = this.storageService.getData('token')

        headers = headers.append('Content-Type', 'application/json')
        headers = headers.append('Access-Control-Allow-Origin', '*')
        headers = headers.append('Authorization', 'Bearer ' + token)

        const url = `${this.baseUrl}/delete_financial/${cod}`
        return this.httpClient.delete<Financial>(url, { headers: headers })
    }
}

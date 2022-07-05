import { Byte } from '@angular/compiler/src/util';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Financial } from '../financial.model';
import { FinancialService } from '../financial.service';
import { Order } from '../order.model';
import { OrderService } from '../order.service';

@Component({
    selector: 'app-order-read',
    templateUrl: './order-read.component.html',
    styleUrls: ['./order-read.component.css']
})

export class OrderReadComponent implements OnInit {

    orders: Order[] = [];
    financials: Financial[] = [];
    displayedColumns: String[] = ['cod', 'creationDate', 'status', 'productsQuantity', 'totalValue', 'flOutput', 'action']
    dataSource = new MatTableDataSource<Order>()
    @ViewChild(MatPaginator)
    paginator!: MatPaginator;

    constructor(private ordeService: OrderService, private financialService: FinancialService, private router: Router, private route: ActivatedRoute) {

    }

    ngOnInit(): void {
        const id = this.route.snapshot.paramMap.get('id')
        if (id !== null) {
            if (id !== "")
                this.deleteOrder(id!)
        }
        this.getFinancials()


        this.ordeService.read().subscribe(orders => {
            this.orders = orders.financialsDetails
            this.dataSource.data = orders.ordersDetails
            this.dataSource.paginator = this.paginator;
        })
    }

    getFinancials(): void {
        this.financialService.read().subscribe(financials => {
            this.financials = financials.financialsDetails

            this.financials.forEach(function (value) {
                var year = new Date(value.inclusionDate).getFullYear()
                var month = new Date(value.inclusionDate).getMonth()
                var day = new Date(value.inclusionDate).getDate()
                value.inclusionDate = new Date(year, month, day)
            });
        })
    }

    deleteOrder(cod: string): void {
        this.ordeService.readById(cod).subscribe(order => {
            let orderVerify = order
            if (orderVerify.status == 1) {
                orderVerify.status = 0
                this.ordeService.update(orderVerify).subscribe(order => {
                    this.ordeService.showMessage(`Pedido [${cod}] cancelado com sucesso.`, 'sucesso')

                });
            }
            else {
                this.ordeService.showMessage(`Pedido [${cod}] já está cancelado.`, 'erro')
            }
            this.router.navigate(['/orders']);
        });
    }
}

import { Byte } from '@angular/compiler/src/util';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Financial, FinancialCharts } from '../financial.model';
import { FinancialService } from '../financial.service';
import { Order } from '../order.model';
import { OrderService } from '../order.service';
import { Chart, ChartConfiguration, ChartItem, registerables } from 'chart.js'

@Component({
    selector: 'app-order-read',
    templateUrl: './order-read.component.html',
    styleUrls: ['./order-read.component.css']
})

export class OrderReadComponent implements OnInit {

    orders: Order[] = [];
    displayedColumns: String[] = ['cod', 'creationDate', 'status', 'productsQuantity', 'totalValue', 'flOutput', 'action']
    financials: Financial[] = [];
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

        this.financialService.read().subscribe(financial => {
            this.financials = financial.financialsDetails;

            this.ordeService.read().subscribe(orders => {
                this.orders = orders.ordersDetails
                this.dataSource.data = orders.ordersDetails
                this.dataSource.paginator = this.paginator;
            })
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

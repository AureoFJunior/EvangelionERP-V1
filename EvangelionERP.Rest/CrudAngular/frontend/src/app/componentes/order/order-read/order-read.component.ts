import { Byte } from '@angular/compiler/src/util';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Financial, FinancialCharts } from '../financial.model';
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
    financialsChart: FinancialCharts[] = [];
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

        this.financialsChart = this.getFinancials(this.financialsChart);

        this.ordeService.read().subscribe(orders => {
            this.orders = orders.financialsDetails
            this.dataSource.data = orders.ordersDetails
            this.dataSource.paginator = this.paginator;
        })
    }

    // Pega as informações do financeiro e vai formatando pra mostrar no gráfico.
    getFinancials(fin: FinancialCharts[]): FinancialCharts[] {
        this.financialService.readChart().subscribe(financials => {
            this.financials = financials.financialsDetails

            let label: string[] = []
            let months: string[] = ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"]
            let datas: number[] = []

            this.financials.forEach(function (value) {
                let year = new Date(value.inclusionDate).getFullYear()
                let month = new Date(value.inclusionDate).getMonth()
                let day = new Date(value.inclusionDate).getDate()

                label.push(`${months[month]}/${year}`)
                datas.push(value.totalValue)
            });

            var chart: FinancialCharts = { label: label, data: datas, tension: 0.5 };
            fin.push(chart);
        });
        return fin;
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

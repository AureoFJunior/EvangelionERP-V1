import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Chart, ChartConfiguration, registerables } from 'chart.js';
import { Financial, FinancialCharts } from '../../componentes/order/financial.model';
import { FinancialService } from '../../componentes/order/financial.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

    financials: Financial[] = [];
    financialsChart: FinancialCharts[] = [];
    chart: any;

    constructor(private financialService: FinancialService, private router: Router, private route: ActivatedRoute) { }

    ngOnInit(): void {

        var labels: string[] = []
        var datas: number[] = []



        this.financialService.readChart().subscribe(financials => {
            this.financials = financials

            let labels: string[] = []
            let months: string[] = ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"]


            this.financials.forEach(function (value) {
                let year = new Date(value.inclusionDate).getFullYear()
                let month = new Date(value.inclusionDate).getMonth()
                let day = new Date(value.inclusionDate).getDate()

                labels.push(`${months[month]}/${year}`)
                datas.push(value.totalValue)
            });

            this.financialsChart.push({ label: "Sales", data: datas, backgroundColor: '#F69D43', tension: 0.2, borderColor: '#F69D43', color: '#FFFFFF' });

            this.chart = document.getElementById('sales-chart');
            Chart.register(...registerables);
            new Chart(this.chart, {
                type: 'line',
                data: {
                    datasets: this.financialsChart,
                    labels: labels
                }
            })
            Chart.defaults.color = "#fff";
        });

        console.log(labels)
        const data = {
            labels: labels,
            datasets: this.financialsChart
        }

        console.log(data)

        const options = {
            scales: {
                y: {
                    beginAtZero: false,
                    display: true
                }
            }
        }

        const config: ChartConfiguration = {
            type: 'line',
            data: data,
            options: options
        }
  }
}

export interface Financial {
    cod: number;
    totalValue: number;
    inclusionDate: Date;
}

export class FinancialCharts {
    label: string[] = [];
    data: number[] = [];
    tension: number = 0;
}
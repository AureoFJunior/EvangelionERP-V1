export interface Financial {
    cod: number;
    totalValue: number;
    inclusionDate: Date;
}

export class FinancialCharts {
    label: string = "";
    data: number[] = [];
    backgroundColor: string = '#F69D43';
    tension: number = 0.2;
    borderColor: string = '#F69D43';
    color: string = '#FFFFFF';
}
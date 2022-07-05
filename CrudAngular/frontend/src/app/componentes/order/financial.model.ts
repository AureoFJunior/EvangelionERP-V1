export interface Financial {
    cod: number;
    totalValue: number;
    inclusionDate: Date;
}

export interface FinancialCharts {
    label: string;
    data: number[];
    tension: number;
}
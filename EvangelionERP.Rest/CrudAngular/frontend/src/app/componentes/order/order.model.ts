import { Byte } from "@angular/compiler/src/util";

export interface Order {
    cod?: number;
    creationDate: Date;
    status?: Byte;
    totalValue: number;
    productsQuantity: number;
    flOutput: boolean;
}
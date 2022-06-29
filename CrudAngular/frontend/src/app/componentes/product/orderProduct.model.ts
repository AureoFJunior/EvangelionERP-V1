import { FormControl, FormGroup } from "@angular/forms";

export class OrderProduct {
    cod: number = 0;
    orderCod: number = 0;
    name: string = "";
    quantity: number = 0;
    price: number = 0;
    productCod: number = 0;
    flOutput: boolean = true;

    static asFormGroup(product: OrderProduct): FormGroup {
        const fg = new FormGroup({
          cod: new FormControl(product.cod),
          name: new FormControl(product.name),
          quantity: new FormControl(product.quantity),
          price: new FormControl(product.price)
        });
        return fg;
    }

}
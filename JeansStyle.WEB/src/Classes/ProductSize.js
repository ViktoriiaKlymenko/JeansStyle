import {Size} from "./Size";

export class ProductSize {
    constructor(
        id,
        amount,
        size
    ) {
        this.id = id
        this.amount = amount
        this.size = new Size(...size)
    }
}
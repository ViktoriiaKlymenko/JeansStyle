import {ProductSize} from "./ProductSize";

export class ProductSizes {
    constructor(productSizes = []) {
        if (!productSizes instanceof Array) {
            throw new TypeError('Sizes should be an array')
        }

        this.productSizes = []

        productSizes.forEach(productSize => {
            this.productSizes.push(new ProductSize(...productSize))
        })
    }
}
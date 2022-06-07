import {Gender} from "./Gender";
import {Category} from "./Category";
import {ProductSizes} from "./ProductSizes";

export class Product {
    constructor(
        id,
        title,
        image,
        description,
        price,
        productSizes,
        gender,
        category
    ) {
        console.log(1)
        this.id = id
        this.title = title
        this.image = image
        this.description = description
        this.price = parseFloat(price).toFixed(2)

        this.productSizes = new ProductSizes(productSizes)
        this.gender = new Gender(...gender)
        this.category = new Category(...category)
    }
}
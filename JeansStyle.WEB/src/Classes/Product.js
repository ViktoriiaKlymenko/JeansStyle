import {Gender} from "./Gender";
import {Category} from "./Category";
import {ProductSize} from "@/Classes/ProductSize";

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
        this.id = id
        this.title = title
        this.image = image
        this.description = description
        this.price = parseFloat(price).toFixed(2)

        this.productSizes = productSizes.forEach(productSize => {
            this.productSizes.push(new ProductSize(...productSize))
        })
        
        this.gender = new Gender(...gender)
        this.category = new Category(...category)
    }
}
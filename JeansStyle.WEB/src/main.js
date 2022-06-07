// Dependencies
import {createApp} from 'vue'

// Components
import CartComponent from "@/components/Cart/CartComponent";
import AddToCartButton from "@/components/Cart/AddToCartButton";
import ProductCard from "@/components/Catalog/ProductCard";

let app = createApp({
    components: {
        CartComponent,
        AddToCartButton,
        ProductCard,
    },
})

app.mount('#app')
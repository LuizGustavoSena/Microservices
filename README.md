# Microservices:
### Stack:

<div style="display: inline_block"><br>
  <img align="center" height="40" width="50" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" />
  <img align="center" height="40" width="50" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/docker/docker-original.svg" />    
  <img align="center" height="40" width="50" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/kubernetes/kubernetes-plain.svg" />
  <img align="center" height="40" width="50" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/mysql/mysql-original.svg" />
  <img align="center" height="40" width="50" src="https://icon.icepanel.io/Technology/svg/RabbitMQ.svg" />
</div>

### About project:

# Project focused for shopping, controls like:

- Products
- Shopping Cart
- Coupons
- Purchase Processing with RabbitMQ

## Products

 ![Shopping.Api](https://github.com/LuizGustavoSena/Microservices/blob/main/images/Shopping.Api.png)

 ## Shopping Cart

 ![Shopping.Car](https://github.com/LuizGustavoSena/Microservices/blob/main/images/Shopping.Car.png)

 ## Coupons

 ![Shopping.Coupon](https://github.com/LuizGustavoSena/Microservices/blob/main/images/Shopping.Coupon.png)

 ## Docker Images:

- Shopping.Api
    ```js
    cd Shopping.Api/
    docker build -t shoppingapi .
    ```
- Shopping.Car
    ```js
    cd Shopping.Car/
    docker build -t shoppingcar .
    ```
- Shopping.Coupon
    ```js
    cd Shopping.Coupon/
    docker build -t shoppingcoupon .
    ```
- Shopping.MessageBus
    ```js
    cd Shopping.MessageBus/
    docker build -t shoppingmessagebus .
    ```
- Shopping.Order
    ```js
    cd Shopping.Order/
    docker build -t shoppingorder .
    ```

## Kubernets:

- Shopping.Api
    ```js
    cd Shopping.Api/
    kubectl apply -f kubernets.yaml -f service.yaml
    ```
- Shopping.Car
    ```js
    cd Shopping.Car/
    kubectl apply -f kubernets.yaml -f service.yaml
    ```
- Shopping.Coupon
    ```js
    cd Shopping.Coupon/
    kubectl apply -f kubernets.yaml -f service.yaml
    ```
- Shopping.MessageBus
    ```js
    cd Shopping.MessageBus/
    kubectl apply -f kubernets.yaml -f service.yaml
    ```
- Shopping.Order
    ```js
    cd Shopping.Order/
    kubectl apply -f kubernets.yaml -f service.yaml
    ```
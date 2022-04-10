# Api Template

## Project layers

- Api
- CrossCutting
- Infrastructure
- Application
- Domain

## **Api**

Api is the presentation layer.

## **CrossCutting**

CrossCutting is a layer that can be accessed by any part of the project. Here is defined Helper classes, Extension methods, authentication context ...

## **Infrastructure**

Infrastructure includes data access implementations.

## **Application**

This layer defines all things our application can do. Here you can find the commands, queries and [validations](#Validation) that represent the application.

## **Domain**

This is where will be defined the entities and interfaces that represents the application.


---

## **Validation**
The validations is defined using the [Fluent Validation](https://fluentvalidation.net/) Package
The project is defined with two types of validation in mind: Request Validations and business logic validations

### Request Validation

This is defines what is a valid request to the API e.g. Value cannot be null, must be lass than 10, must not be empty...
Any request that does not meet those requirements will return a ``400 BadRequest``

### Business Validations

This is all validation related to business definition e.g. Date must be between certain range, Item must be unique, invalid account number... 

BusinessValidation classes must end with ``Spec`` in their names.

---

## Controller Endpoint naming convention

Each domain must have its own controller file

Each controller method must have a declarative name showing what type of action it is suppose to do eg UpdateUserPassword, UpdateItemColor, CancelOrder...

Example of router names to follow

- /orders
- /orders/578
- /orders/578/update-requirement

For more info check this useful website https://restfulapi.net/resource-naming/


## Todo
- [ ] Unit tests
- [ ] Integrated tests with Specflow
- [ ] Authentication






# Buber Dinner Api

- [Buber Dinner API](#buber-dinner-api)
    -[Auth](#auth)
        -[Register](#register)
            -[Register Request](#register-request)
            -[Register Response](#register-response)
        -[Login](#login)
            -[Login Request](#login-request)
            -[Login Response](#login-response)
    

## Auth

### Register

```js
POST {{host}}/v1/auth/register
```

#### Register Request

```json
{
    "firstName": "Laura",
    "lastName": "Brito",
    "email": "email@email.com",
    "password": "password123",
}
```

#### Register Response

```js
200 OK
```

```json
{
    "id": "Guid",
    "firstName": "Laura",
    "lastName": "Brito",
    "email": "email@email.com",
    "token": "token",
}
```


### Login

```js
POST {{host}}/v1/auth/login
```

#### Login Request

```json
{
    "email": "email@email.com",
    "password": "password123"
}
```

#### Login Response

```js
200 OK
```

```json
{
    "id": "Guid",
    "firstName": "Laura",
    "lastName": "Brito",
    "email": "email@email.com",
    "token": "token",
}
```
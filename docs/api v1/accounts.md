# Accounts

## Get by id
Requires authorization: __no__

### Request Sample

```js
GET {host}/api/v1/accounts/{userId}
```

### Success Response Sample

```js
OK 200
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "imageUri": "bloggy.com/images/user_image_00000000-0000-0000-0000-000000000000.png",
    "name": "Cyril",
    "email": "cyril@mail.com"
}
```

## My
Requires authorization: __yes__

### Request Sample

```js
GET {host}/api/v1/accounts/my
```

### Success Response Sample

```js
OK 200
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "imageUri": "bloggy.com/images/user_image_00000000-0000-0000-0000-000000000000.png",
    "name": "Cyril",
    "email": "cyril@mail.com"
}
```

## Change password
Requires authorization: __yes__

### Request Sample

```js
PUT {host}/api/v1/accounts/change-password
```

### Success Response Sample

```js
OK 200
```

```json
{
    "oldPassword": "12345678",
    "newPassword": "87654321"
}
```

## Delete
Requires authorization: __yes__

### Request Sample

```js
DELETE {host}/api/v1/accounts/my
```

### Success Response Sample

```js
OK 200
```

## Create image
Requires authorization: __yes__

### Request Sample

```js
POST {host}/api/v1/accounts/my/images
```

### Success Response Sample

```js
OK 200
```

## Delete image
Requires authorization: __yes__

### Request Sample

```js
DELETE {host}/api/v1/accounts/my/images
```

### Success Response Sample

```js
OK 200
```

## Update image
Requires authorization: __yes__

### Request Sample

```js
PUT {host}/api/v1/accounts/my/images
```

### Success Response Sample

```js
OK 200
```

## Get all topics
Requires authorization: __no__

### Request Sample

```js
GET {host}/api/v1/topics/
```

### Success Response Sample

```js
OK 200
```

```json
{
    topics: [
        {
            "id": 0,
            "name": "topic_name"
        }
    ]
}
```
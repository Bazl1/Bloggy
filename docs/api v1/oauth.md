# OAuth

## Register
Requires authorization: __no__

### Request Sample

```js
POST {host}/api/v1/oauth/register
```
```json
{
    "username": "Cyril",
    "email": "cyril@mail.com",
    "password": "cyril123"
}
```

### Success Response Sample
```js
OK 200
```

```json
{
    "accessToken": "jkasd23...123d",
    "refreshToken": "jk12sd23...123d",
}
```

## Login
Requires authorization: __no__

### Request Sample

```js
POST {host}/api/v1/oauth/login
```
```json
{
    "email": "cyril@mail.com",
    "password": "cyril123"
}
```

### Success Response Sample
```js
OK 200
```

```json
{
    "accessToken": "jkasd23...123d",
    "refreshToken": "jk12sd23...123d",
}
```

## Logout
Requires authorization: __yes__

### Request Sample

```js
POST {host}/api/v1/oauth/logout
```

### Success Response Sample
```js
OK 200
```
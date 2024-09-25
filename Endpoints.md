# Endpoints 

The API is prepared to manage a complete CRUD for each entity, however we pay all our attention to the ones that are actually being consumed by the frontend in this first version, that's why we are emphasizing those endpoints in this documentation. In future releases, each DTO will be reviewed to ensure the best handling of the missing endpoints.  

- [Auth](#Auth)
- [Flight](#Flight)
- [Food](#Food)
- [Hotel](#Hotel)
- [People](#People)
- [Reserves](#Reserves)
- [Review](#Review)
- [Room](#Room)
- [Tour](#Tour)

## Principal Endpoints

### Auth

```
  POST /api/V1/Auth/login
```
| Parameter | Type     | Description                 |
| :-------- | :------- | :-------------------------- |
|           |          | Returns JWT and Person info |

<br>

### Flight

```
  GET/api/V1/Flight
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
|           |          | Returns all the Flights    |

<br>

### Food

```
  GET/api/V1/Food
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
|           |          | Returns all the Foods      |

<br>

### Hotel

```
  GET/api/V1/Hotel
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
|           |          | Returns all the Hotels     |

<br>

### People

```
  GET/api/V1/People
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
|           |          | Returns all the People     |

<br>

```
  POST/api/V1/People
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
|           |          | Create a person in the DB  |

<br>


### Reserve

```
  GET/api/V1/Reserve
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
|           |          | Returns all the Reserves   |

<br>

## Get by PersonId

```
  GET/api/person/{id}
```
| Parameter | Type     | Description                                 |
| :-------- | :------- | :-----------------------------------------  |
|    id     |  int     | Returns the reserves for an specific person |

### Room

```
  GET/api/V1/Room
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
|           |          | Returns all the Tours      |

<br>

## Other endpoints structure

### Post (Create)

```
  POST/api/V1/{Entity}
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
|           |          | Create a data in the DB    |

<br>

### Get by Id (Read)

```
  GET/api/V1/{Entity}/{id}
```
| Parameter | Type     | Description                              |
| :-------- | :------- | :--------------------------------------  |
|    id     |  int     | Returns the information of specific data |

<br>

### Put (Update)

```
  PUT/api/V1/{Entity}/{id}
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
|    id     |  int     |                            |

<br>

### Delete (Delete)

```
  DELETE/api/V1/{Entity}/{id}
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
|    id     |  int     |                            |

<br>


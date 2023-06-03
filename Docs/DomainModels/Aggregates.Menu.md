# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Guid dinnerId);
    void UpdateSection(MenuSection section);
}
```

```json
{
    "id": "Guid",
    "name": "Yummy Menu",
    "description": "A menu with yummy food",
    "averageRating": 4.7,
    "sections": [
        {
            "id": "Guid",
            "name": "Appetizers",
            "description": "Starters",
            "items":[
                {
                    "id": "Guid",
                    "name": "Fried Pickles",
                    "description": "Deep fried pickles",
                    "price": 9.99
                }
            ]
        }
        
    ],
    "createdDateTime": "2023-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2023-01-01T00:00:00.0000000Z",
    "hostId": "Guid",
    "dinnerIds": [
        "Guid",
    ],
    "menuReviewIds": [
        "Guid",
    ]
}
```
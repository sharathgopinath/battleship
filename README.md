# Battleship State Tracking API
An API to track the status of a Battleship game.
Board size - 10x10
Co-ordinates - a1, b1, c1... to j10

## API Endpoints
HTTP GET **api/battle-ship/new**

Creates a new board and adds a battleship to the board

Example Output - 
```
{
    "gameProgressCode": "q8UbImDGvIfPyCjKtolwiiMbFPr/hB52ejBnckxL9SOGWWaWo9BmGqtYlZ/NvR/H",
    "hits": [],
    "misses": []
}
```

HTTP POST **api/battle-ship/game-status**

Returns the current status of the game

Example Input - 
```
{
	gameProgressCode: "q8UbImDGvIfPyCjKtolwiiMbFPr/hB52qdpSu/4J2+0SjnfVSUpq1rWhkXo7OuR4KujOjUbQ/jw="
}
```

Example Output - 
```
{
    "hits": [
        "d2",
        "e2"
    ],
    "misses": [
        "c2"
    ]
}
```

HTTP POST **api/battle-ship/attack**

Attack at a given position, reports back with the current status of the game
**Note** Ensure you send the updated 'gameProgressCode' for subsequent requests to this API endpoint to maintain the game's progress

Example Input - 
```
{
	gameProgressCode: "q8UbImDGvIfPyCjKtolwiiMbFPr/hB52e6E1eRafGnySdoO0c/Geg68b3Awu6bj1L10U64yntY0=",
	coOrd: "e2"
}
```

Example Output - 
```
{
    "gameProgressCode": "q8UbImDGvIfPyCjKtolwiiMbFPr/hB52qdpSu/4J2+0SjnfVSUpq1rWhkXo7OuR4KujOjUbQ/jw=",
    "hits": [
        "d2",
        "e2"
    ],
    "misses": [
        "c2"
    ]
}
```


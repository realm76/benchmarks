package main

import (
	"strconv"
	"time"

	"github.com/gofiber/fiber/v2"
)

type User struct {
	Id        int
	FirstName string
	LastName  string
	CreatedAt time.Time
}

func main() {
	app := fiber.New()

	app.Get("/users/sync", func(c *fiber.Ctx) error {
		var users [1000]User

		for x := 0; x < 1000; x++ {
			strIndex := strconv.Itoa(x)
			users[x] = User{
				Id:        x,
				FirstName: "FirstName" + strIndex,
				LastName:  "LastName" + strIndex,
				CreatedAt: time.Now(),
			}
		}

		return c.JSON(users)
	})

	app.Listen(":1000")
}

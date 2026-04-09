# Fetching data from a website
# Working with HTML and CSV

import requests
from bs4 import BeautifulSoup
import csv


def scrape_data():
    url = "https://books.toscrape.com/catalogue/category/books/travel_2/index.html"

    response = requests.get(url)
    response.encoding = "utf-8"

    soup = BeautifulSoup(response.text, "html.parser")

    books = soup.find_all("article", class_="product_pod")

    data = []

    for book in books:

        title = book.h3.a["title"]

        price = book.find("p", class_="price_color").text.replace("Â", "").strip()

        rating = book.find("p", class_="star-rating")["class"][1]

        data.append([title, price, rating])

    return data


def save_to_csv(data):
    file = open("books.csv", "w", newline="", encoding="utf-8")
    writer = csv.writer(file)

    writer.writerow(["Title", "Price", "Rating"])

    for row in data:
        writer.writerow(row)

    file.close()
    print("Data saved to books.csv")


def read_csv():
    print("\nDisplaying data from CSV:\n")

    file = open("books.csv", "r", encoding="utf-8")
    reader = csv.reader(file)

    for row in reader:
        print(row)

    file.close()


def main():
    print("\n--- Task 4 ---\n")

    data = scrape_data()
    save_to_csv(data)
    read_csv()


if __name__ == "__main__":
    main()
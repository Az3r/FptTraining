import requests
from pathlib import Path
from bs4 import BeautifulSoup
import json


def get_books():
    file = Path("Mocks/books.html")
    if not file.exists():
        page = requests.get(
            "https://www.goodreads.com/list/show/1.Best_Books_Ever")
        file.write_bytes(page.content)

    soup = BeautifulSoup(file.read_bytes(), "html.parser")
    books = soup.find_all('span', itemprop="name", limit=10)
    return [item.text for item in books]


def get_cars():
    file = Path("Mocks/cars.html")
    if not file.exists():
        page = requests.get(
            "https://www.izmostock.com/car-stock-photos-by-brand")
        file.write_bytes(page.content)

    soup = BeautifulSoup(file.read_bytes(), "html.parser")
    cars = soup.find_all('span', id="by_brand_caption", limit=10)
    return [item.text for item in cars]


def get_tvs():
    file = Path("Mocks/tvs.html")
    if not file.exists():
        page = requests.get(
            "https://en.wikipedia.org/wiki/List_of_television_manufacturers")
        file.write_bytes(page.content)

    soup = BeautifulSoup(file.read_bytes(), "html.parser")
    tvs = soup.find_all('a', class_="mw-redirect", limit=12)
    tvs.pop(0)
    tvs.pop(0)
    return [item.text for item in tvs]


def get_laptops():
    file = Path("Mocks/laptops.html")
    if not file.exists():
        page = requests.get(
            "https://en.wikipedia.org/wiki/List_of_laptop_brands_and_manufacturers")
        file.write_bytes(page.content)

    soup = BeautifulSoup(file.read_bytes(), "html.parser")
    laptop = soup.find_all('a', class_="mw-redirect", limit=15)
    laptop.pop(0)
    laptop.pop(0)
    return [item.text for item in laptop]


def get_phones():
    file = Path("Mocks/phones.html")
    if not file.exists():
        page = requests.get(
            "https://www.91mobiles.com/top-10-mobiles-in-india")
        file.write_bytes(page.content)

    soup = BeautifulSoup(file.read_bytes(), "html.parser")
    phones = soup.find_all('td', limit=15)
    return [item.text for item in phones]


books = get_books()
cars = get_cars()
tvs = get_tvs()
laptops = get_laptops()
phones = get_phones()

data = {
    "books": books,
    "cars": cars,
    "tvs": tvs,
    "laptops": laptops,
    "phones": phones
}
Path("Mocks/products.json").write_text(json.dumps(data, indent=2))

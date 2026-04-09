# TCP server
# Accepts a connection from a client
# Receives customer data
# Stores data in database
# Sends registration number back to client

import socket
import sqlite3

def create_database():
    conn = sqlite3.connect("car_rental.db")
    cursor = conn.cursor()

    cursor.execute("""
        CREATE TABLE IF NOT EXISTS customers (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            name TEXT NOT NULL,
            address TEXT NOT NULL,
            pps_number TEXT NOT NULL,
            driving_license TEXT NOT NULL,
            registration_number TEXT NOT NULL UNIQUE
        )
    """)

    conn.commit()
    conn.close()


def generate_registration_number():
    conn = sqlite3.connect("car_rental.db")
    cursor = conn.cursor()

    cursor.execute("SELECT COUNT(*) FROM customers")
    count = cursor.fetchone()[0]

    conn.close()

    return "REG" + str(count + 1).zfill(3)


def save_customer(name, address, pps_number, driving_license, registration_number):
    conn = sqlite3.connect("car_rental.db")
    cursor = conn.cursor()

    cursor.execute("""
        INSERT INTO customers (name, address, pps_number, driving_license, registration_number)
        VALUES (?, ?, ?, ?, ?)
    """, (name, address, pps_number, driving_license, registration_number))

    conn.commit()
    conn.close()


def TCP_server():
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    host = '127.0.0.1'
    port = 9999

    try:
        create_database()

        sock.bind((host, port))
        print("Server is ready ...")

        sock.listen()
        print("Server is listening for connections...")

        con, addr = sock.accept()
        print(f"Server is connected to {addr}")

        msg = con.recv(1024)
        data = msg.decode()
        print("Client data received:", data)

        parts = data.split(" | ")

        if len(parts) == 4:
            name = parts[0]
            address = parts[1]
            pps_number = parts[2]
            driving_license = parts[3]

            registration_number = generate_registration_number()

            save_customer(name, address, pps_number, driving_license, registration_number)

            reply = "Registration successful. Registration Number: " + registration_number
            con.sendall(reply.encode())
            print("Data stored successfully.")
        else:
            con.sendall(b"Invalid data received.")
            print("Invalid data received.")

        con.close()
        print("Server is closed...")

    except TimeoutError:
        print("Time out error...")
    except OSError:
        print("OS error...")
    except KeyboardInterrupt:
        print("Process is killed ...")
    except Exception as e:
        print("Error: ", e)
    finally:
        sock.close()


def main():
    print("\n - - - - TCP Server - - - - \n")
    TCP_server()

if __name__ == "__main__":
    main()
# TCP client
# Sends customer data to TCP server
# Receives registration number from server

import socket

def TCP_client():
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    host = '127.0.0.1'
    port = 9999

    try:
        sock.connect((host, port))
        print("Client is ready ....")

        name = input("Enter your name: ")
        address = input("Enter your address: ")
        pps_number = input("Enter your PPS number: ")
        driving_license = input("Enter your driving license number: ")

        msg = name + " | " + address + " | " + pps_number + " | " + driving_license
        sock.sendall(msg.encode())

        data = sock.recv(1024)
        print("Server: ", data.decode())

    except ConnectionRefusedError:
        print("Connection refused...")
    except ConnectionAbortedError:
        print("Connection is aborted...")
    except ConnectionError:
        print("Connection error...")
    except Exception as e:
        print("Error: ", e)
    finally:
        sock.close()
        print("Client is closed...")


def main():
    print("\n - - - - TCP Client - - - - \n")
    TCP_client()

if __name__ == "__main__":
    main()
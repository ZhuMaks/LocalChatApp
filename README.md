# Chat Application

A real-time chat application developed in C# using WPF and MVVM architecture. This project includes both the server and client components, enabling multiple users to connect, exchange messages, and manage connections seamlessly.

---

## Features

- **Server-Client Architecture**: 
  - Server manages user connections and broadcasts messages.
  - Client handles user interactions and communication with the server.

- **Real-Time Messaging**: 
  - Broadcast messages to all connected users.
  - Notify users of new connections and disconnections.

- **User Management**:
  - Display a list of connected users in the client interface.
  - Handle user disconnections gracefully.

- **Customizable UI**:
  - Light/Dark theme toggle.
  - Responsive and user-friendly interface designed with WPF.

---

## Project Structure

### Server Components
- **`Program`**: Entry point for the server. Handles user connections and broadcasts messages.
- **`Client`**: Represents a connected user.
- **`PacketBuilder`**: Constructs data packets to send to clients.
- **`PacketReader`**: Reads incoming data packets.

### Client Components
- **`MainViewModel`**: 
  - Implements data binding and commands for the UI.
  - Handles server communication events such as message reception and user updates.
- **`Server`**: 
  - Manages the client's connection to the server.
  - Sends messages and handles incoming packets.
- **`PacketBuilder`** and **`PacketReader`**:
  - Used for constructing and parsing data packets.

---

## Setup Instructions

### Prerequisites
- .NET Framework 4.7.2 or later.
- Visual Studio or another C# IDE.

### Running the Application

1. **Start the Server**:
   - Navigate to the `ChatServer` project directory.
   - Build and run the server application.
   - The server listens on `127.0.0.1:7891`.

2. **Start the Client**:
   - Navigate to the `ChatClient` project directory.
   - Build and run the client application.
   - Enter a username and click `Connect`.

3. **Send Messages**:
   - Type a message in the text box and press "Send" or hit Enter.

---

## Key Files

### Server
- **`Program.cs`**: Server entry point.
- **`Client.cs`**: Handles individual user connections.
- **`PacketBuilder.cs`**: Constructs outgoing packets.
- **`PacketReader.cs`**: Parses incoming packets.

### Client
- **`MainWindow.xaml`**: WPF layout for the client interface.
- **`MainViewModel.cs`**: Logic for binding data and handling commands.
- **`Server.cs`**: Client's communication logic.





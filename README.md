# Asp.NetCore
Asp.Net Core version 3.1 and above demos.

## 1. Three.One
A demo of MVC.

## 2. ThreePage
A demo of Razor page.

## 3. ThreeSignalR
* A demo of SignalR. 
* SignalR 使用了三种“底层”技术来实现实时web, 它们分别是：Long Polling, Server Sent Events 和 Websocket。
Polling是实现实时web的一种笨办法，它就是通过定期的向服务器发送请求，来查看服务器的数据是否有变化。
* 如果服务器数据没变化，就返回204 NoContent；如果有变化，就把最新的数据发送给客户端。
* 这就是Polling，很简单，但是比较浪费资源。
* SignalR没有采用Polling这种技术。
* Long Polling和Polling有类似的地方，客户端都是发送请求到服务器。但是不同之处在于：如果服务器没有新数据要发给客户端的话，那么服务器会继续保持连接，直到有新的数据产生，服务器才把新的数据返回给客户端。
* 如果请求发生后一段时间内没有响应，那么请求就会超时。这时，客户端会再次发出请求。


## 4. ThreeBlazor
A demo of Blazor.

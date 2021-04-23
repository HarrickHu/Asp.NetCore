# Asp.NetCore
Asp.Net Core version 3.1 and above demos.

## 1. Three.One
A demo of MVC.

## 2. ThreePage
A demo of Razor page.

## 3. ThreeSignalR
__A demo of SignalR.__ 
__SignalR 使用了三种“底层”技术来实现实时web, 它们分别是：Long Polling, Server Sent Events 和 Websocket。__
### Long Polling
* Polling是实现实时web的一种笨办法，它就是通过定期的向服务器发送请求，来查看服务器的数据是否有变化。
如果服务器数据没变化，就返回204 NoContent；如果有变化，就把最新的数据发送给客户端。
* 这就是Polling，很简单，但是比较浪费资源。
* SignalR没有采用Polling这种技术。
* Long Polling和Polling有类似的地方，客户端都是发送请求到服务器。但是不同之处在于：如果服务器没有新数据要发给客户端的话，那么服务器会继续保持连接，直到有新的数据产生，服务器才把新的数据返回给客户端。
* 如果请求发生后一段时间内没有响应，那么请求就会超时。这时，客户端会再次发出请求。
### Server Sent Events(SSE)
* 使用SSE的话，Web服务器可以在任何时间把数据发送给浏览器，可以称之为推送，而浏览器则会监听进来的信息，这些信息就像流数据一样，这个连接也会一直保持开放，直到服务器主动关闭它。
* 浏览器会使用一个叫做EventSource的对象用来处理传过来的信息。
### Web Socket
* Web Socket是不同于Http的另一个TCP协议，它使得浏览器和服务器之间的交互式通信变得可能。使用WebSocket，消息可以从服务器发往客户端，也可以从客户端发往服务器，并且没有Http那样的延迟。信息流没有完成的时候，TCP Socket通常是保持打开的状态。
* 使用现代浏览器时，SignalR大部分情况下都会使用Web Socket，这也是最有效的传输方式。
* 全双工通信：客户端和服务器可以同时往对方发送消息。
* 并且不受SEE的那个浏览器连接数限制（6个），大部分浏览器对Web Socket连接数的限制是50个。
* 消息类型：可以是文本和二进制，Web Socket也支持流媒体（音频和视频）。
* 其实正常的Http请求也是用了TCP Socket。Web Socket标准使用了握手机制把用于Http的Socket升级为使用WS协议的WebSocket socket。


## 4. ThreeBlazor
A demo of Blazor.

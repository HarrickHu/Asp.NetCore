# Asp.NetCore
Asp.Net Core version 3.1 and above demos.

## 1. Three.One
A demo of MVC.

## 2. ThreePage
A demo of Razor page.

## 3. ThreeSignalR
A demo of SignalR.  
SignalR是一个.NET Core/.NET Framework的开源实时框架。
SignalR使用了三种“底层”技术来实现实时web, 它们分别是：Long Polling, Server Sent Events 和 Web socket。   
SignalR基于这三种技术构建，抽象于它们之上，它让你更好的关注业务问题而不是底层传输技术问题。  
SignalR这个框架分服务器和客户端，服务器支持ASP.Net Core 和ASP.Net; 而客户端除了支持浏览器里的JavaScript以外，也支持其他类型的客户端，例如桌面应用。  
SignalR采用了回落机制，它有能力去协商支持的这三种传输类型。也可以禁用这种回落机制，而只选择其中一种。  
RPC(Remote Procedure Call). 它的优点就是可以抽象调用本地方法一样调用远程服务。  
SignalR采用RPC方式来进行客户端与服务器之间的通信。  
SignalR利用底层传输来让服务器可以调用客户端的方法，反之亦然，这些方法可以带参数，参数也可以是复杂对象，SignalR负责序列化和反序列化。  
#### Long Polling
* Polling是实现实时web的一种笨办法，它就是通过定期的向服务器发送请求，来查看服务器的数据是否有变化。
如果服务器数据没变化，就返回204 NoContent；如果有变化，就把最新的数据发送给客户端。
* 这就是Polling，很简单，但是比较浪费资源。
* SignalR没有采用Polling这种技术。
* Long Polling和Polling有类似的地方，客户端都是发送请求到服务器。但是不同之处在于：如果服务器没有新数据要发给客户端的话，那么服务器会继续保持连接，直到有新的数据产生，服务器才把新的数据返回给客户端。
* 如果请求发生后一段时间内没有响应，那么请求就会超时。这时，客户端会再次发出请求。
#### Server Sent Events(SSE)
* 使用SSE的话，Web服务器可以在任何时间把数据发送给浏览器，可以称之为推送，而浏览器则会监听进来的信息，这些信息就像流数据一样，这个连接也会一直保持开放，直到服务器主动关闭它。
* 浏览器会使用一个叫做EventSource的对象用来处理传过来的信息。
* 对于浏览器的要求较Web Socket可能好一点，但是也存在同样的问题。
#### Web Socket
* Web Socket是不同于Http的另一个TCP协议，它使得浏览器和服务器之间的交互式通信变得可能。使用WebSocket，消息可以从服务器发往客户端，也可以从客户端发往服务器，并且没有Http那样的延迟。信息流没有完成的时候，TCP Socket通常是保持打开的状态。
* 仅支持比较现代的浏览器，web服务器也不能太老。  
* 使用现代浏览器时，SignalR大部分情况下都会使用Web Socket，这也是最有效的传输方式。
* 全双工通信：客户端和服务器可以同时往对方发送消息。
* 并且不受SEE的那个浏览器连接数限制（6个），大部分浏览器对Web Socket连接数的限制是50个。
* 消息类型：可以是文本和二进制，Web Socket也支持流媒体（音频和视频）。
* 其实正常的Http请求也是用了TCP Socket。Web Socket标准使用了握手机制把用于Http的Socket升级为使用WS协议的WebSocket socket。
* Web Socket生命周期，所有的一切都发生在TCP Socket里面：Http握手（首先一个常规的Http请求会要求服务器更新socket并协商）->通信/数据交换->关闭
* Http握手，每一个Web Socket开始的时候都是一个简单的Http Socket。客户端首先发送一个Get请求到服务器，来请求升级Socket。如果服务器同意的话，这个Socket从这时开始就变成了Web Socket。   
* Web Socket的消息类型可以是文本，二进制，也包括控制类的消息：Ping/Pong, 和关闭。
* 每个消息由一个或多个Frame组成


## 4. ThreeBlazor
A demo of Blazor.

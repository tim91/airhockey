#pragma strict
     
    var ipAddress : String = "127.0.0.1";
    var port : int = 25000;
    var maxConnections : int = 10;
      var lab = "ALA";
      
    function OnGUI() {
     
    GUILayout.BeginHorizontal();
    ipAddress = GUILayout.TextField(ipAddress);
    GUILayout.Label("IP ADDRESS");
    GUILayout.EndHorizontal();
     
    GUILayout.BeginHorizontal();
    var tempPort : String;
    tempPort = GUILayout.TextField(port.ToString());
    port = parseInt(tempPort);
    GUILayout.Label("PORT");
    GUILayout.EndHorizontal();
     
    if(GUILayout.Button("CONNECT")) {
    print("connecting... ");
    lab = "Trwa laczenie";
    Network.Connect(ipAddress, port);
    lab = "Koniec laczenia";
    }

    if(GUILayout.Button("START SERVER")) {
    lab = "Startuje serwer";
    print("starting server on " + ipAddress + ":" + port);
    Network.InitializeServer(maxConnections, port);
    lab = "Wystartowal serwer";
    
    }
     
         GUILayout.BeginHorizontal();
   
    GUILayout.Label(lab);
    GUILayout.EndHorizontal(); 
    }
     
    function OnConnectedToServer() {
    print("connected :)");
     lab = "Polaczono!!!!";
     
    }


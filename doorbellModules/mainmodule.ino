#include <RCSwitch.h>
#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>



String apiKeyValue = "xxx";

const char* ssid="xxx";
const char* password="xxx";


const char* serverName = "http://remotedoorbell.azurewebsites.net/ring";
#define RX_PIN 4
#define ledPin 5
#define buzzer 14

RCSwitch mySwitch = RCSwitch();
void setup() {
  Serial.begin(9600);
  mySwitch.enableReceive(4);
  pinMode(ledPin, OUTPUT);
  pinMode(buzzer, OUTPUT);

  Serial.println("Connecting to ");
  Serial.println(ssid);

  WiFi.begin(ssid,password);

  while(WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
    
  }
  Serial.println(" ");
  Serial.println("WiFi connected");
  Serial.print("Your IP: ");  
  Serial.print(WiFi.localIP());




}

void loop() {
  String httpRequest= "";
  HTTPClient http;
  http.begin(serverName);
  http.addHeader("Content-Length", "0");
  http.addHeader("Token", apiKeyValue);

  
  if (mySwitch.available()) {
    uint16_t m=mySwitch.getReceivedValue();
    if(m==5393)
    {
         digitalWrite(ledPin,HIGH);
         digitalWrite(buzzer,HIGH);
         int httpResponseCode = http.POST(httpRequest);  
         http.end();
         delay(3000);
    }
    
    }
   digitalWrite(ledPin,LOW);
   digitalWrite(buzzer,LOW);
   mySwitch.resetAvailable();
  }

#include <RCSwitch.h>
#include <avr/sleep.h>


#define ledPin 1

RCSwitch mySwitch = RCSwitch();

void usp () {
  set_sleep_mode(SLEEP_MODE_PWR_DOWN);
  ADCSRA &= ~(1<<ADEN);       // Turn off ADC to save power
  sleep_enable();
  sleep_cpu();
}

void setup() {
 pinMode(ledPin, OUTPUT);
 mySwitch.enableTransmit(0);
 mySwitch.setRepeatTransmit(15);

}

void loop() {
   
   digitalWrite(1, HIGH);
   mySwitch.send("000000000001010100010001");
   delay(3000);
   digitalWrite(1, LOW); 
   usp();
   }


/*
  This code blinks the name "ASMI" using an Arduino.

  The code uses the following pins:
    * ledPin: The pin that the LED is connected to.
    * pushbuttonPin: The pin that the pushbutton is connected to.

  The code works by first defining the duration of a dot, dash, letter, and word.
  Then, it defines functions for blinking a dot and a dash.
  Next, it defines a function for blinking a letter, which takes a character as input.
  Then, it defines the setup() and loop() functions.

  In the setup() function, the pins are set as outputs and the LED is turned off.
  In the loop() function, the button state is read.
  If the button state changes from HIGH to LOW, the name blinking state is toggled.
  If the name blinking state is true, the name is blinked.

  The name is blinked by calling the blinkLetter() function for each letter in the name.
  The delay() function is used to wait between each letter.
*/

// Pin configurations
const int ledPin = 13;   // The pin that the LED is connected to.
const int pushbuttonPin = 2;   // The pin that the pushbutton is connected to.

//time in milliseconds
const int dottime = 200;   // Duration of a dot
const int dashtime = 2 * dottime;  // Duration of a dash 
const int lettertime = 4 * dottime;  // Space for letters 
const int wordtime = 6 * dottime;  // Space for words

// Function for blinking a dot.
void dot() {
  // Turn the LED on.
  digitalWrite(ledPin, HIGH); // To wait for dottime millisecondsspecified time
  // Wait for the specified time.
  delay(dottime);
  // Turn the LED off.
  digitalWrite(ledPin, LOW); //To wait for dottime milliseconds(specified time)
  delay(dottime);
}

// Function for blinking a dash.
void dash() {
  // Turn the LED on.
  digitalWrite(ledPin, HIGH);  // To Wait for dashtime milliseconds(specified time)
  delay(dashtime);
  // Turn the LED off.
  digitalWrite(ledPin, LOW); // To Wait for dashtime milliseconds(specified time)
  delay(dottime);
}

// Function for blinking a letter.
void blinkLetter(char abc) {
  // Switch on the character.
  switch (abc) {
    case 'A':
      dot(); dash();
      break;
    case 'S':
      dot(); dot(); dot();
      break;
    case 'M':
      dash(); dash();
      break;
    case 'I':
      dot(); dot();
      break;
    
    default:
      break;
  }
}

// Setup function.
void setup() {
  // To set the LED pin as an output.
  pinMode(ledPin, OUTPUT);
  pinMode(pushbuttonPin, INPUT_PULLUP);
  // To turn the LED off.
  digitalWrite(ledPin, LOW);
}

// Loop function.
void loop() {
  // Read the button state.
  static bool pushbuttonState = HIGH;
  static bool previousButtonState = HIGH;
  static bool nameBlinking = false;

  pushbuttonState = digitalRead(pushbuttonPin);// To read the state of the push button
   // ToCheck if the button is pressed and released
  // If the button state changes from HIGH to LOW, toggle the name blinking state.
  if (pushbuttonState == LOW && previousButtonState == HIGH) {
    nameBlinking = !nameBlinking; // To toggle the name blinking state 
    if (nameBlinking) {
      // Starts to Blink the name "ASMI" using Morse code
      const char name[] = "ASMI"; 
      for (int i = 0; i < sizeof(name) - 1; i++) {
        blinkLetter(name[i]); // To blink the current letter
        delay(lettertime); //To wait for the space between letters
      }
      delay(wordtime);// To wait for the space between words
    }
  }

  // To update the previous button state.
  previousButtonState = pushbuttonState;
}
/*
                          111111111111111111                                                        111111111111111111                          
                    111111111111111111111111111111                                            111111111111111111111111111111                    
                11111111111111111111111111111111111111                                    11111111111111111111111111111111111111                
              11111111111111111111111111111111111111111111                            11111111111111111111111111111111111111111111              
          11111111111111111111111111111111111111111111111111                        111111111111111111111111111111111111111111111111            
        111111111111111111111111111111111111111111111111111111                    1111111111111111111111111111111111111111111111111111          
        11111111111111111111              1111111111111111111111                11111111111111111111                11111111111111111111        
      1111111111111111                          111111111111111111            111111111111111111                        111111111111111111      
    1111111111111111                              111111111111111111        1111111111111111                                1111111111111111    
    11111111111111                                    1111111111111111    1111111111111111                                    11111111111111    
  11111111111111                                        11111111111111  1111111111111111                                        11111111111111  
  111111111111                                            1111111111111111111111111111                                          11111111111111  
11111111111111                                            11111111111111111111111111                    111111                    111111111111  
111111111111                                                111111111111111111111111                    111111                    11111111111111
111111111111                                                  11111111111111111111                      111111                      111111111111
111111111111            111111111111111111111111                1111111111111111                  111111111111111111                111111111111
111111111111            111111111111111111111111                1111111111111111                  111111111111111111                111111111111
111111111111            111111111111111111111111                1111111111111111                  111111111111111111                111111111111
111111111111                                                  111111111111111111                        111111                      111111111111
111111111111                                                  11111111111111111111                      111111                      111111111111
111111111111                                                111111111111111111111111                    111111                    111111111111  
11111111111111                                            1111111111111111111111111111                                            111111111111  
  111111111111                                          111111111111111111111111111111                                          11111111111111  
  11111111111111                                        11111111111111    11111111111111                                        11111111111111  
    11111111111111                                    11111111111111      1111111111111111                                    11111111111111    
    1111111111111111                              111111111111111111        1111111111111111                                1111111111111111    
      111111111111111111                        111111111111111111            111111111111111111                        111111111111111111      
        11111111111111111111                11111111111111111111                11111111111111111111                11111111111111111111        
        111111111111111111111111111111111111111111111111111111                    1111111111111111111111111111111111111111111111111111          
            111111111111111111111111111111111111111111111111                        111111111111111111111111111111111111111111111111            
              11111111111111111111111111111111111111111111                            11111111111111111111111111111111111111111111              
                11111111111111111111111111111111111111                                  11111111111111111111111111111111111111                  
                    111111111111111111111111111111                                          111111111111111111111111111111                      
                          111111111111111111                                                      111111111111111111                            
                                                                                                                                                
                                                                                                                                                
                                                                                                                                                
        11111111        111111111111        111111111111        1111        111111    1111111111111111    111111      1111        1111111111    
        11111111        11111111111111      1111111111111111    1111        111111    1111111111111111    111111      1111      11111111111111  
      1111111111        1111      111111    1111      111111    1111        111111        111111          11111111    1111    111111    111111  
      1111  111111      1111      111111    1111        111111  1111        111111        111111          11111111    1111    1111        111111
      1111  111111      1111      111111    1111        111111  1111        111111        111111          1111111111  1111  111111        111111
      1111    1111      11111111111111      1111        111111  1111        111111        111111          1111  1111  1111  111111        111111
    111111    1111      111111111111        1111        111111  1111        111111        111111          1111  1111  1111  111111        111111
    1111111111111111    1111    111111      1111        111111  1111        111111        111111          1111  1111111111  111111        111111
    1111111111111111    1111      1111      1111        111111  111111      111111        111111          1111    11111111    1111        111111
  111111        1111    1111      111111    1111    11111111    111111      1111          111111          1111    11111111    111111    111111  
  1111          111111  1111      111111    11111111111111        11111111111111      1111111111111111    1111      111111      111111111111    
  1111          111111  1111        111111  1111111111              1111111111        1111111111111111    1111      111111        11111111      

							                                                  WITH NITR0_CH4RG3R								
*/

bool laserIn = false;
bool laserOut = false;
bool colorBall = false;
bool fin1 = false;
bool fin2 = false;
bool fin3 = false;
bool fin4 = false;
bool fout1 = false;
bool fout2 = false;
bool fout3 = false;
bool fout4 = false;

int laserInP = 2;
int laserOutP = 3;
int colorBallP = 4;
int fin1P = 5;
int fin2P = 6;
int fin3P = 7;
int fin4P = 8;
int fout1P = 9;
int fout2P = 10;
int fout3P = 11;
int fout4P = 12;

void setup() {
  pinMode(laserInP,OUTPUT);
  pinMode(laserOutP,OUTPUT);
  pinMode(colorBallP,OUTPUT);
  pinMode(fin1P,OUTPUT);
  pinMode(fin2P,OUTPUT);
  pinMode(fin3P,OUTPUT);
  pinMode(fin4P,OUTPUT);
  pinMode(fout1P,OUTPUT);
  pinMode(fout2P,OUTPUT);
  pinMode(fout3P,OUTPUT);
  pinMode(fout4P,OUTPUT);
  pinMode(LED_BUILTIN,OUTPUT);

  Serial.begin(115200);
  digitalWrite(LED_BUILTIN,HIGH);
  delay(3000);
  digitalWrite(LED_BUILTIN,LOW);
  
}

void loop() 
{
  byte serialRead;
  if(Serial.available())
  {
    serialRead = Serial.read();
    
    //for Laser in
    if(serialRead == '0')
    {
      if(laserIn == false)
      {
        digitalWrite(laserInP,HIGH);
        laserIn = true;
      }
      else
      {
         digitalWrite(laserInP,LOW);
         laserIn = false;   
      }
    }

    //for Laser out
    if(serialRead == '1')
    {
      if(laserOut == false)
      {
        digitalWrite(laserOutP,HIGH);
        laserOut = true;
      }
      else
      {
         digitalWrite(laserOutP,LOW);
         laserOut = false;   
      }
    }

    //for Color Ball
    if(serialRead == '2')
    {
      if(colorBall == false)
      {
        digitalWrite(colorBallP,HIGH);
        colorBall = true;
      }
      else
      {
         digitalWrite(colorBallP,LOW);
         colorBall = false;   
      }
    }

    //for Flasher IN
    
    //1
    if(serialRead == 'a')
    {
      if(fin1 == false)
      {
        digitalWrite(fin1P,HIGH);
        fin1 = true;
      }
      else
      {
        digitalWrite(fin1P,LOW);
        fin1 = false;
      }
    }

    //2
    if(serialRead == 'b')
    {
      if(fin2 == false)
      {
        digitalWrite(fin2P,HIGH);
        fin2 = true;
      }
      else
      {
        digitalWrite(fin2P,LOW);
        fin2 = false;
      }
    }

    //3
    if(serialRead == 'c')
    {
      if(fin3 == false)
      {
        digitalWrite(fin3P,HIGH);
        fin3 = true;
      }
      else
      {
        digitalWrite(fin3P,LOW);
        fin3 = false;
      }
    }

    //4
    if(serialRead == 'd')
    {
      if(fin4 == false)
      {
        digitalWrite(fin4P,HIGH);
        fin4 = true;
      }
      else
      {
        digitalWrite(fin4P,LOW);
        fin4 = false;
      }
    }

    //Flashers Out

    //1
    if(serialRead == 'A')
    {
      if(fout1 == false)
      {
        digitalWrite(fout1P,HIGH);
        fout1 = true;
      }
      else
      {
        digitalWrite(fout1P,LOW);
        fout1 = false;
      }
    }

    //2
    if(serialRead == 'B')
    {
      if(fout2 == false)
      {
        digitalWrite(fout2P,HIGH);
        fout2 = true;
      }
      else
      {
        digitalWrite(fout2P,LOW);
        fout2 = false;
      }
    }

    //3
    if(serialRead == 'C')
    {
      if(fout3 == false)
      {
        digitalWrite(fout3P,HIGH);
        fout3 = true;
      }
      else
      {
        digitalWrite(fout3P,LOW);
        fout3 = false;
      }
    }

    //4
        if(serialRead == 'D')
    {
      if(fout4 == false)
      {
        digitalWrite(fout4P,HIGH);
        fout4 = true;
      }
      else
      {
        digitalWrite(fout4P,LOW);
        fout4 = false;
      }
    }
  }
}

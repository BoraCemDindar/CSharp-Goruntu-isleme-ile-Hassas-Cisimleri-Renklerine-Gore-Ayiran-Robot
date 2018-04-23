#include <Servo.h>

Servo myservoyaw;
Servo myservopitch;
Servo myservoroll;
Servo myservoaci;

int pos = 0;  


const int in1=11;
const int in2=12;
const int e2=5;

char Char;
String x, y, z, i, t,k,l,m,n,o,p ;
int val1, val2, val3, val4, val5, buton;
int b=0;
int aa,ab,ac,ba,bb,bc;
int tas1,tas2,tas3,tas4,tas5,tas6;
int aad,abd,acd,bad,bbd,bcd,cad,cbd,ccd;
int konum1=90,konum2=90,konum3=50;
int hedef1=90,hedef2=90,hedef3=50,hedef4=50;
int govdeaci1,govdeaci2,govdeaci3,teta1,teta2,teta3,phi1,phi2,phi3;
int k1=0,k2=0,k3=0,k4=0,k5=0,k6=0;
int t1=0,t2=0,t3=0,t4=0,t5=0,t6=0;


int pot = A1;
int deger = 0;
int m1;
int m2;
int m3;
int f=1;
void setup() {
  // put your setup code here, to run once:
   
}

void ali()
{
     
        
}
void mehmet()
{
  
}




void loop() {
  // put your main code here, to run repeatedly:
 

 if(Serial.available()>1)
  {
      
      Char=Serial.read();
      if(Char='a');
      {
         i=Serial.readStringUntil(',');
        val4 = i.toInt();// C# - Motor-1'den Gönderilen Deger

         t=Serial.readStringUntil('/');
        buton = t.toInt();// C# - Motor-1'den Gönderilen Deger

        x=Serial.readStringUntil(';');
        aad = x.toInt();// C# - Motor-1'den Gönderilen Deger
        y=Serial.readStringUntil(':');
        abd = y.toInt();// C# - Motor-1'den Gönderilen Deger
        z=Serial.readStringUntil('&');
        acd = z.toInt();// C# - Motor-1'den Gönderilen Deger
        k=Serial.readStringUntil('<');
        bad = k.toInt();// C# - Motor-1'den Gönderilen Deger
        l=Serial.readStringUntil('>');
        bbd = l.toInt();// C# - Motor-1'den Gönderilen Deger
        m=Serial.readStringUntil('=');
        bcd = m.toInt();// C# - Motor-1'den Gönderilen Deger
        n=Serial.readStringUntil('?');
        cad = n.toInt();// C# - Motor-1'den Gönderilen Deger
        o=Serial.readStringUntil('*');
        cbd = o.toInt();// C# - Motor-1'den Gönderilen Deger
        p=Serial.readStringUntil('|');
        ccd = p.toInt();// C# - Motor-1'den Gönderilen Deger
        
        
                        
        if(buton==10)
        { 
           
         
         
        }
        if(buton==40)
        {
          
           
         
        }

        if(buton==50)
        {
          
         
        }



        if(buton==90)
        {


          
        }
        
        if(buton==100)
        {
        }
      }
  }
}

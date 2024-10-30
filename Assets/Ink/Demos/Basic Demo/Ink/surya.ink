VAR knowledge = 0
VAR wisdom = 0
VAR empathy = 0

-> start

=== start ===
-eh sur cabut gak?
  * [Kalau sesuai keinginan saya... lebih baik tetap di tempat.]
    ~ wisdom += 0
    ~ empathy += -1
    ~ knowledge += 1
    -> weird
  
  * [Enggak, mending jangan cabut]
    ~ wisdom += 1
    ~ empathy += 1
    ~ knowledge += 1
    -> good
    
  * [Mending tetap aja.] 
   ~ wisdom += 0
    ~ empathy += 0
    ~ knowledge += 0
  -> weird
    
=== weird ===
- apasih bocah culun gak jelas
    -> DONE




=== good ===
- lah emang kenapa 
 * [Karena tetap di sini lebih aman dan strategis.]
  ~ wisdom += 0
    ~ empathy += 0
    ~ knowledge += 2
    -> weird
 * [sekarang mata-mata guru sedang banyak]
  ~ wisdom += 1
    ~ empathy += 2
    ~ knowledge += 1
    -> good1
 * [saat nya sekolah]
    ~ wisdom += 0
    ~ empathy += 0
    ~ knowledge += 0
    -> weird
    
    
=== good1 ===
- ada benernya juga 


-> END
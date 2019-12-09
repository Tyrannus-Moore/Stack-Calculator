# Stack-Calculator
 A stack based WinForm Calculator.
 ![image](https://github.com/Tyrannus-Moore/Stack-Calculator/blob/master/Images/Stack-Calculator.gif)
 
## Algorithm
 We will use two stacks OPTR(OPeraToRs),OPND(OPeraNDs) for storing operators and operands respectively.   And the table below shows how the calculator works.
<table border="0">
  <th>ID</th>
  <th>OPTR</th>
  <th>OPND</th>
  <th>Ready to input</th>
  <th>Operation</th>
   <tr>
    <td>0</td>
    <td></td>
    <td></td>
    <td><b>#</b>3*(7+2)#</td>
    <td>push(OPTR,'#')</td>
  </tr>
  <tr>
    <td>1</td>
    <td>#</td>
    <td></td>
    <td><b>3</b>*(7+2)#</td>
    <td>push(OPND,'3')</td>
  </tr>
   <tr>
    <td>2</td>
    <td>#</td>
    <td>3</td>
    <td><b>*</b>(7+2)#</td>
    <td>push(OPTR,'*')</td>
  </tr>
   <tr>
    <td>3</td>
    <td>#*</td>
    <td>3</td>
    <td><b>(</b>7+2)#</td>
    <td>push(OPTR,'(')</td>
  </tr>
   <tr>
    <td>4</td>
    <td>#*(</td>
    <td>3</td>
    <td><b>7</b>+2)#</td>
    <td>push(OPND,'7')</td>
  </tr>
   <tr>
    <td>5</td>
    <td>#*(</td>
    <td>3 7</td>
    <td><b>+</b>2)#</td>
    <td>push(OPTR,'+')</td>
  </tr>
   <tr>
    <td>6</td>
    <td>#*(+</td>
    <td>3 7</td>
    <td><b>2</b>)#</td>
    <td>push(OPND,'2')</td>
  </tr>
   <tr>
    <td>7</td>
    <td>#*(+</td>
    <td>3 7 2</td>
    <td><b>)</b>#</td>
    <td>operate('7' + '2')</td>
  </tr>
   <tr>
    <td>8</td>
    <td>#*(</td>
    <td>3 9</td>
    <td><b>)</b>#</td>
    <td>offsetBracket</td>
  </tr>
  <tr>
    <td>9</td>
    <td>#*</td>
    <td>3 9</td>
    <td><b>#</b></td>
    <td>operate('3' + '9')</td>
  </tr>
   <tr>
    <td>10</td>
    <td>#</td>
    <td>2 7</td>
    <td><b>#</b></td>
    <td>offsetOctothorpe</td>
  </tr>
</table>

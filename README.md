# Stack-Calculator
 A stack based WinForm Calculator.
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
    <td>#3*(7+2)#</td>
    <td>push(OPTR,'#')</td>
  </tr>
  <tr>
    <td>1</td>
    <td>#</td>
    <td></td>
    <td>3*(7+2)#</td>
    <td>push(OPND,'3')</td>
  </tr>
   <tr>
    <td>2</td>
    <td>#</td>
    <td>3</td>
    <td>*(7+2)#</td>
    <td>push(OPTR,'*')</td>
  </tr>
   <tr>
    <td>3</td>
    <td>#*</td>
    <td>3</td>
    <td>(7+2)#</td>
    <td>push(OPTR,'(')</td>
  </tr>
   <tr>
    <td>4</td>
    <td>#*(</td>
    <td>3</td>
    <td>7+2)#</td>
    <td>push(OPND,'7')</td>
  </tr>
   <tr>
    <td>5</td>
    <td>#*(</td>
    <td>3 7</td>
    <td>+2)#</td>
    <td>push(OPTR,'+')</td>
  </tr>
   <tr>
    <td>6</td>
    <td>#*(+</td>
    <td>3 7</td>
    <td>2)#</td>
    <td>push(OPND,'2')</td>
  </tr>
   <tr>
    <td>7</td>
    <td>#*(+</td>
    <td>3 7 2</td>
    <td>)#</td>
    <td>operate('7' + '2')</td>
  </tr>
   <tr>
    <td>8</td>
    <td>#*(</td>
    <td>3 9</td>
    <td>)#</td>
    <td>offsetBracket</td>
  </tr>
  <tr>
    <td>9</td>
    <td>#*</td>
    <td>3 9</td>
    <td>#</td>
    <td>operate('3' + '9')</td>
  </tr>
   <tr>
    <td>10</td>
    <td>#</td>
    <td>2 7</td>
    <td>#</td>
    <td>offsetOctothorpe</td>
  </tr>
</table>

function my() {
    var mywindow = window.open('', 'PRINT', 'height=400,width=600');

    mywindow.document.write(document.getElementById("divtoprint").innerHTML);

    mywindow.document.close(); // necessary for IE >= 10
    mywindow.focus(); // necessary for IE >= 10*/

    mywindow.print();
    mywindow.close();

    return true;
}
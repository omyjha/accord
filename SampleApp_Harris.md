The Harris sample application demonstrates how to perform corners detection using the [Harris algorithm](http://crsouza.blogspot.com/2010/05/harris-corners-detector-in-c.html).

<br /><p align='center'>
<img src='http://accord.googlecode.com/svn/wiki/samples/accord-imaging-harris-img.png' />
<br />Harris corners detection in the world-famous Lena Söderberg's picture.<br>
</p><br />


The current implementation supports both [Harris and Nobel corner measures](http://accord.googlecode.com/svn/docs/html/T_Accord_Imaging_HarrisCornerMeasure.htm). Harris can be enabled by checking the checkbox next to the ''k'' parameter, which is only needed for Harris. The Nobel measure does not require setting any parameters.

A suitable choice for the threshold parameter when using Harris measure may range around 10,000 to 30,000, while when using Nobel it may range around 20 to 100. Best sigma values are usually higher than 0.3 and lesser than 5.0.
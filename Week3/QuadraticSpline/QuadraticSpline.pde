ArrayList<PVector> clickablePoints = new ArrayList<PVector>();

PVector draggingPoint = null;

void setup() {
  size(800, 500);

  for (int i = 0; i< 10; i++) {

    float x = random(0, width);
    float y = random(0, height);
    PVector p = new PVector(x, y);
    clickablePoints.add(p);
  }
}

void draw() {
  if (draggingPoint !=null) {
    draggingPoint.x += mouseX - pmouseX;
    draggingPoint.y += mouseY - pmouseY;
  }

  background(128);
  drawSpline();
  drawAnchors();

  float time = millis()/1000.0;
  float p = map(sin(time), -1, 1, 0, 1);
  PVector pos = spline(p);
  fill(255, 0, 0);
  ellipse(pos.x, pos.y, 20, 20);
  fill(255);
}

void drawSpline() {
  int numCurves = clickablePoints.size()-2;

  for (int i = 1; i<numCurves; i++) {
    PVector a = clickablePoints.get(i-1);
    PVector b = clickablePoints.get(i);
    PVector c = clickablePoints.get(i+1);

    if (i>1) a = PVector.lerp(a, b, .5);
    if (i<numCurves) c = PVector.lerp(b, c, .5);

    drawCurve(a, b, c);
  }
}

void drawCurve(PVector a, PVector b, PVector c) {
  int res = 10;

  PVector prevPt = new PVector();
  for (int i= 0; i<= res; i++) {
    float p = i/(float)res;
    PVector pt = bez(a, b, c, p);
    if ( i>0) line(pt.x, pt.y, prevPt.x, prevPt.y);
    ellipse(pt.x, pt.y, 5, 5);

    prevPt = pt;
  }
}

void drawAnchors() {
  for (int i=0; i<clickablePoints.size(); i++) {
    PVector p = clickablePoints.get(i);
    if (i>0) {
      PVector pp = clickablePoints.get(i-1);
      stroke(100);
      line(pp.x, pp.y, p.x, p.y);
    }
    stroke(0);
    ellipse(p.x, p.y, 20, 20);
  }
}

PVector spline(float p) {
  p = constrain(p, 0, 1);
  int numOfCurves = clickablePoints.size()-2;
  float percentPerCurve = 1/ numOfCurves;

  int index = 1;
  while (p > percentPerCurve) {
    p -= percentPerCurve;
    index++;
  }
  p/= percentPerCurve;
  PVector a = clickablePoints.get(index-1);
  PVector b = clickablePoints.get(index);
  PVector c = clickablePoints.get(index+1);

  if (index>1) a = PVector.lerp(a, b, .5);
  if (index<numOfCurves) c = PVector.lerp(b, c, .5);

  return bez(a, b, c, p);
}

PVector bez(PVector a, PVector b, PVector c, float p) {
  p = constrain(p, 0, 1);

  PVector p1 = PVector.lerp(a, b, p);
  PVector p2 = PVector.lerp(b, c, p);


  return PVector.lerp(p1, p2, p);
}

void mousePressed() {
  draggingPoint = null;
  for (PVector p : clickablePoints) {
    float dx = p.x - mouseX; //distance from mouse (on x Axis)
    float dy = p.y - mouseY; //distance from mouse (on y Axis)
    float d = (dx*dx+dy*dy);

    float radiusSqrd = 10*10;

    if (d < radiusSqrd) {
      //point p was clicked on!
      draggingPoint = p;
      break;
    }
  }
}

void mouseReleased() {
  draggingPoint = null;
}
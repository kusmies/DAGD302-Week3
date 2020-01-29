PVector a = new PVector(100, 300);
PVector b = new PVector(400, 400);
PVector c = new PVector(700, 100);
PVector d = new PVector(500, 200);

ArrayList<PVector> clickablePoints = new ArrayList<PVector>();

PVector draggingPoint = null;

void setup() {
  size(800, 500);

  clickablePoints.add(a);
  clickablePoints.add(b);
  clickablePoints.add(c);
  clickablePoints.add(d);
}

void draw() {
  if (draggingPoint !=null) {
    draggingPoint.x += mouseX - pmouseX;
    draggingPoint.y += mouseY - pmouseY;
  }

  background(128);
  drawCurve();
  drawAnchors();
  
  float time = millis()/1000.0;
  float p = map(sin(time), -1,1,0,1);;
  PVector pos = bez(a,b,c,d,p);
  fill(255,0,0);
  ellipse(pos.x, pos.y,20,20);
  fill(255);
}

void drawCurve() {
  int res = 10;

  PVector prevPt = new PVector();
  for (int i= 0; i<= res; i++) {
    float p = i/(float)res;
    PVector pt = bez(a, b, c, d, p);
    if ( i>0) line(pt.x, pt.y, prevPt.x, prevPt.y);
    ellipse(pt.x, pt.y, 5, 5);

    prevPt = pt;
  }
}

void drawAnchors() {
  stroke(100);
  line(a.x, a.y, b.x, b.y);
  line(b.x, b.y, c.x, c.y);
  line(c.x, c.y, d.x, d.y);
  stroke(0);
  ellipse(a.x, a.y, 20, 20);
  ellipse(b.x, b.y, 20, 20);
  ellipse(c.x, c.y, 20, 20);
  ellipse(d.x, d.y, 20, 20);
}

PVector bez(PVector a, PVector b, PVector c, PVector d, float p) {
  p = constrain(p, 0, 1);

  PVector p1 = PVector.lerp(a, b, p);
  PVector p2 = PVector.lerp(b, c, p);
  PVector p3 = PVector.lerp(c, d, p);
  
  PVector p4 = PVector.lerp(p1,p2,p);
  PVector p5 = PVector.lerp(p2,p3, p);

  return PVector.lerp(p4, p5, p);
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
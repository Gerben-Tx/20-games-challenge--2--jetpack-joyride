shader_type canvas_item;

uniform float SPEED = 0.5;
uniform float CUSTOM_TIME = 0.0;

void vertex() {
	UV.x += CUSTOM_TIME * SPEED;
}
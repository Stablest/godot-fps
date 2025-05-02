shader_type canvas_item;

uniform vec4 crosshair_color : source_color = vec4(1.0, 1.0, 1.0, 1.0);
uniform float thickness = 0.01; // Thickness of the lines (0.0–0.5)
uniform float length = 0.2;     // Length of each line arm (0.0–0.5)
uniform float gap = 0.03;       // Size of transparent gap in center

void fragment() {
    vec2 center = vec2(0.5, 0.5);
    vec2 uv = UV - center;
    vec2 abs_uv = abs(uv);

    // Horizontal line, excluding the center gap
    float h_line = step(abs_uv.y, thickness) * step(abs_uv.x, length) * step(gap, abs_uv.x);

    // Vertical line, excluding the center gap
    float v_line = step(abs_uv.x, thickness) * step(abs_uv.y, length) * step(gap, abs_uv.y);

    float cross = max(h_line, v_line);

    COLOR = vec4(crosshair_color.rgb, crosshair_color.a * cross);
}
extends CharacterBody2D
class_name Player

@export var move_speed: float = 70.0

@export var character_rig: CharacterRig

var input_dir: Vector2

func _physics_process(delta: float) -> void:
	_move(delta)

func _move(delta: float) -> void:
	input_dir = Input.get_vector("MoveLeft", "MoveRight", "MoveUp", "MoveDown")
	input_dir = input_dir.normalized()
	
	if input_dir != Vector2.ZERO:
		velocity = input_dir * move_speed * delta
	else:
		velocity = Vector2.ZERO
	move_and_slide()

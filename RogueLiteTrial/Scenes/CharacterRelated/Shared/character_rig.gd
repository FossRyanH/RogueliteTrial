extends Node2D
class_name CharacterRig

@export var anim_player: AnimationPlayer
@export var anim_tree: AnimationTree

@onready var statemachine_playerback = anim_tree.get("parameters/playback")

func update_animations(movement: Vector2) -> void:
	pass

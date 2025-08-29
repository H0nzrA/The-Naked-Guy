# 📑 Game Design Document -- *Coin Collector*

## 1. **Vision du Jeu**

Un jeu 2D simple où le joueur déplace un personnage pour ramasser des
pièces et éviter des ennemis.\
But : **atteindre le plus haut score possible** avant de perdre.

------------------------------------------------------------------------

## 2. **Genre**

- Arcade 2D\
- Contrôles simples, durée courte\
- Score basé sur les pièces collectées

------------------------------------------------------------------------

## 3. **Plateforme**

- PC (Windows/Linux/Mac)\
- Contrôles clavier

------------------------------------------------------------------------

## 4. **Mécaniques de Jeu**

### 🎮 Joueur

- Se déplace avec les touches fléchées ou ZQSD.\
- Vitesse fixe (`Speed`).\
- Collision avec les murs → il reste dans l'arène.

### 🟡 Pièces

- Apparaissent aléatoirement dans l'arène.\
- Si le joueur touche une pièce → **+1 point**, la pièce disparaît et
 une nouvelle apparaît ailleurs.

### 🔴 Ennemi

- Se déplace automatiquement (patrouille horizontale/verticale ou
 mouvement aléatoire).\
- Si le joueur touche l'ennemi → **Game Over**.

### 📊 Score

- Score affiché en haut de l'écran via un **Label**.\
- Game Over → message affiché et bouton "Rejouer".

------------------------------------------------------------------------

## 5. **Boucle de Jeu**

1. Le joueur se déplace.\
2. Cherche à ramasser les pièces.\
3. Évite les ennemis.\
4. Score augmente à chaque pièce collectée.\
5. Collision avec un ennemi → **perte** → retour à l'écran Game Over.

------------------------------------------------------------------------

## 6. **Progression / Difficulté**

- Chaque pièce collectée → fait réapparaître une nouvelle pièce
 ailleurs.\
- Possibilité d'ajouter plus d'ennemis après X points (pour augmenter
 la difficulté).

------------------------------------------------------------------------

## 7. **Interface (HUD)**

- **Score** : affiché en haut à gauche.\
- **Message Game Over** : affiché quand le joueur perd.\
- **Bouton Rejouer** : pour recommencer la partie.

------------------------------------------------------------------------

## 8. **Scènes dans Godot**

 Main.tscn      → gère la logique générale (spawn pièces, ennemis, restart).
 Player.tscn    → joueur contrôlé par le clavier.
 Coin.tscn      → pièce collectable.
 Enemy.tscn     → ennemi qui se déplace automatiquement.
 HUD.tscn       → interface (Label + bouton).

------------------------------------------------------------------------

## 9. **Scripts C# associés**

- **Player.cs** : mouvement joueur, détection collisions.\
- **Coin.cs** : gère la collecte.\
- **Enemy.cs** : mouvement automatique + collision.\
- **HUD.cs** : affiche le score, Game Over et bouton Restart.\
- **Main.cs** : gère spawn des objets, score global et reset.

------------------------------------------------------------------------

## 10. **Style visuel et sonore**

- Graphismes minimalistes (formes géométriques simples pour commencer
 : carré pour joueur, cercle pour pièce, carré rouge pour ennemi).\
- Plus tard : sprites personnalisés.\
- Effet sonore pour ramasser une pièce, son d'échec pour Game Over.

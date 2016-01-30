"""Randomly generate tags, topics, and decisions into json

Example:

    python -m religio.ipsum

"""

import json
import random

ipsumfile = "data/ipsum.json"


def create_tags():
    data = _data()
    id, taggable = random.choice(list(enumerate(data)))
    tags = input("Write space separated tags"
                 " for '%s'\n> "
                 % data[id]['content']).split()
    try:
        data[id]['tags'].extend(tags)
    except AttributeError:
        data[id]['tags'] = tags
    _write(data)
    return tags


def create_topic():
    data = _data()
    topic = {
        "type": "Topic",
        "content": input("Write content for a topic: "),
        "tags": [],
    }
    data.append(topic)
    _write(data)
    return topic


def create_decision():
    data = _data()
    if len(data) == 0:
        return
    print(list(enumerate(data)))
    topic = random.choice(list(filter(
        lambda topic: data[1]['type'] in ["Topic"],
        enumerate(data))))
    decision_content = input("Write a decision for (%s)\n " % topic)
    decision = {
        "type": "Decision",
        "content": decision_content,
        "topic": topic_id,
        "tags": []
    }
    data.append(decision)
    _write(data)
    return decision


def main():
    create_topic()
    while(True):
        random.choice([create_tags, create_topic, create_decision])()


def _data():
    try:
        return json.load(open(ipsumfile))
    except:
        _data = []
        json.dump([], open(ipsumfile, 'w'), indent=2)
        return _data


def _write(data):
    json.dump(data, open(ipsumfile, "w"), indent=2)


if __name__ == '__main__':
    main()
